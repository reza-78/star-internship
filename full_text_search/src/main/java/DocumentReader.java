import lombok.SneakyThrows;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class DocumentReader {
    @SneakyThrows
    List<Term> readDocs() {
        List<Term> terms = new ArrayList<>();
        Scanner scanner;
        File docsDirectory = new File("EnglishData");
        File[] docs = docsDirectory.listFiles();

        for (int i = 0; i < docs.length; i++) {
            scanner = new Scanner(docs[i]);
            while (scanner.hasNext())
                terms.add(new Term(scanner.next(), i));
        }
        return terms;
    }
}
