import requests, json


# scrapes google's autocomplete feature
def getRelatedTopics(query):
    URL = f'http://suggestqueries.google.com/complete/search?client=firefox&q={query}'
    response = requests.get(URL)
    result = json.loads(response.content.decode('utf-8'))[1]
    print(result)
    return result


# returns frequency dict of predict next characters
def getMostLikelyNextCharacters(phrase, suggestions):
    potentialChars = dict()
    for suggestion in suggestions:
        # find end of phrase
        nextCharIndex = len(phrase) + suggestion.rfind(phrase.lower())
        # get next viable character
        while nextCharIndex < len(suggestion):
            nextChar = suggestion[nextCharIndex]
            if nextChar != ' ':
                potentialChars[nextChar] = potentialChars.get(nextChar, 0) + 1
                break
            nextCharIndex += 1
    return potentialChars


# returns either complete words or fragments of words in a frequency dict
def getMostLikelyNextFragments(phrase, suggestions):
    likelyWords = dict()
    for suggestion in suggestions:
        # phrase end included so we don't draw next word from input phrase
        phraseEnd = len(phrase) + suggestion.rfind(phrase.lower())
        suggestion = suggestion[phraseEnd:]
        try:
            nextWord = suggestion.split()[0]
        except IndexError:
            # case where phrase lies within single word suggestion
            nextWord = suggestion[phraseEnd:]
        likelyWords[nextWord] = likelyWords.get(nextWord, 0) + 1
    return likelyWords


def autoComplete(phrase, useContext=True):
    if not useContext:
        # focus on last word of phrase
        phrase = phrase.split()[-1]
    suggestions = getRelatedTopics(phrase)
    mostLikelyCharacters = getMostLikelyNextCharacters(phrase, suggestions)
    mostLikelyNextWords = getMostLikelyNextFragments(phrase, suggestions)
    if mostLikelyCharacters != {} or mostLikelyNextWords != {}:
        return mostLikelyCharacters, mostLikelyNextWords
    else:
        # if unable to generate suggestions from entire context... focus on last word
        print('here')
        lastWord = phrase.split()[-1]
        suggestions = getRelatedTopics(lastWord)
        mostLikelyCharacters = getMostLikelyNextCharacters(lastWord, suggestions)
        mostLikelyNextWords = getMostLikelyNextFragments(lastWord, suggestions)
        return mostLikelyCharacters, mostLikelyNextWords


# uncomment the below to test code
# print(autoComplete('Elon Musk has'))
