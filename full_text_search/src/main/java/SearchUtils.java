import lombok.RequiredArgsConstructor;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;

@RequiredArgsConstructor
public class SearchUtils {
    private final Map<String, List<Integer>> invertedIndex;
    private List<String> mandatoryWords;
    private List<String> atLeastIncludeWords;
    private List<String> excludeWords;

    List<Integer> simpleSearch(String word) {
        return invertedIndex.get(word);
    }

    List<Integer> complexSearch(String exp) {
        mandatoryWords = new ArrayList<>();
        atLeastIncludeWords = new ArrayList<>();
        excludeWords = new ArrayList<>();
        parseExp(exp);
        List<Integer> docsIncludeMandatoryWords = docsIncludeMandatoryWords = findDocsIncludeMandatoryWords();
        List<Integer> docsIncludeMandatoryAndAtListWords = findDocsAtLeastIncludeWords(docsIncludeMandatoryWords);
        return findDocsExcludeWords(docsIncludeMandatoryAndAtListWords);
    }

    private void parseExp(String exp) {
        String[] words = exp.split(" ");
        for (String word : words) {
            if (word.charAt(0) == '+')
                atLeastIncludeWords.add(word.substring(1));
            else if (word.charAt(0) == '-')
                excludeWords.add(word.substring(1));
            else
                mandatoryWords.add(word);
        }
    }

    private List<Integer> findDocsIncludeMandatoryWords() {
        List<List<Integer>> allDocksIncludeMandatoryWords = new ArrayList<>();
        for(String word: mandatoryWords) {
            allDocksIncludeMandatoryWords.add(invertedIndex.get(word));
        }
        return intersection(allDocksIncludeMandatoryWords);
    }

    private List<Integer> findDocsAtLeastIncludeWords(List<Integer> answerSoFar) {
        List<List<Integer>> allDocsAtLeastInclude = new ArrayList<>();
        for(String word: atLeastIncludeWords) {
            allDocsAtLeastInclude.add(invertedIndex.get(word));
        }
        return union(allDocsAtLeastInclude, answerSoFar);
    }

    private List<Integer> findDocsExcludeWords(List<Integer> answerSoFar) {
        List<Integer> allDocksExcludeWords = new ArrayList<>();
        for(String word: excludeWords) {
            allDocksExcludeWords.addAll(invertedIndex.get(word));
        }
        answerSoFar.removeAll(allDocksExcludeWords);
        return answerSoFar;
    }

    private List<Integer> union(List<List<Integer>> lists, List<Integer> answerSoFar) {
        Stream<Integer> concatenated = Stream.concat(answerSoFar.stream(), lists.get(0).stream());
        for (int i = 1; i < lists.size(); i++) {
            concatenated = Stream.concat(concatenated, lists.get(i).stream());
        }
        return concatenated.distinct().collect(Collectors.toList());
    }

    private List<Integer> intersection(List<List<Integer>> lists) {
        List<Integer> intersectionList = new ArrayList<>(lists.get(0));
        for (int i = 1; i < lists.size(); i++) {
            intersectionList.stream().filter(lists.get(i)::contains).collect(Collectors.toList());
        }
        return intersectionList;
    }
}
