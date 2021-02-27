import torch
import string
from transformers import BertTokenizer, BertForMaskedLM

""""The following code is adapted from: 
https://github.com/pandeynandancse/next_word_prediction_streamlit/blob/master/next_word.py"""


def loadModel(model_name):
    try:
        if model_name.lower() == "bert":
            bertTokenizer = BertTokenizer.from_pretrained('bert-base-uncased')
            bertModel = BertForMaskedLM.from_pretrained('bert-base-uncased').eval()
            return bertTokenizer, bertModel
        else:
            print('Other predictive models not yet supported.')
    except Exception as e:
        print(f'Error: {e}')


# transform model tokens into regular language
def decode(tokenizer, predIDx, top_clean):
    ignoreTokens = string.punctuation + '[PAD]'
    tokens = []
    for w in predIDx:
        token = ''.join(tokenizer.decode(w).split())
        if token not in ignoreTokens:
            tokens.append(token.replace('##', ''))
    return '\n'.join(tokens[:top_clean])


# turn phrase into tokens model can understand
def encode(tokenizer, textSentence, add_special_tokens=True):
    textSentence = textSentence.replace('<mask>', tokenizer.mask_token)
    # if <mask> is the last token, append a "." so that models dont predict punctuation.
    if tokenizer.mask_token == textSentence.split()[-1]:
        textSentence += ' .'

        inputIDs = torch.tensor([tokenizer.encode(textSentence, add_special_tokens=add_special_tokens)])
        maskIDx = torch.where(inputIDs == tokenizer.mask_token_id)[1].tolist()[0]
    return inputIDs, maskIDx


# handles model level requirements
def getAllPredictions(text_sentence, predModel, predTokenizer, topClean=5, wordsToPredict=5):
    # ========================= BERT =================================
    input_ids, mask_idx = encode(predTokenizer, text_sentence)
    with torch.no_grad():
        predict = predModel(input_ids)[0]
    bert = decode(predTokenizer, predict[0, mask_idx, :].topk(wordsToPredict).indices.tolist(), topClean)
    return bert


def getPredictedEos(phrase, predModel, predTokenizer, wordsToPredict=5):
    try:
        phrase += ' <mask>'
        res = getAllPredictions(phrase, predModel, predTokenizer, wordsToPredict)
        return res
    except Exception as error:
        pass


"""Add frequency dict or confidence for predictions. Extend predictions to include characters."""


# tokenizer/ model is accepted as argument to avoid continual loading
def autoComplete(phrase, langTokenizer, langModel, wordsToPredict=5):
    try:
        predictedWords = []
        res = getPredictedEos(phrase, langModel, langTokenizer, wordsToPredict)
        # extracts predicted words from model output
        for i in res.split("\n"):
            predictedWords.append(i)
        return predictedWords
    except Exception as e:
        print(f'Error: {e}')


# uncomment the below to test code
# langTokenizer, langModel = loadModel('BERT')
# print(autoComplete('There a lot of dogs', langTokenizer=langTokenizer, langModel=langModel))


