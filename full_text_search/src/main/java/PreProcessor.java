import java.util.*;

public class PreProcessor {
    Map<String, List<Integer>> createInvertedIndex(List<Term> terms) {
        terms.sort(Comparator.comparing(Term::getWord));
        return integrateSameTerms(terms);
    }

    private Map<String, List<Integer>> integrateSameTerms(List<Term> terms) {
        Map<String, List<Integer>> invertedIndex = new HashMap<>();
        for (Term term: terms) {
            String termWord = term.getWord();
            if (invertedIndex.containsKey(termWord)) {
                invertedIndex.get(termWord).add(term.getDocId());
            } else {
                invertedIndex.put(termWord, new ArrayList<>(List.of(term.getDocId())));
            }
        }
        return invertedIndex;
    }
}
