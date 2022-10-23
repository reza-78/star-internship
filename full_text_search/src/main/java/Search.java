import java.util.Scanner;

public class Search {
    public static void properSearching() {
        Scanner scanner = new Scanner(System.in);
        DocumentReader documentReader = new DocumentReader();
        PreProcessor preProcessor = new PreProcessor();
        SearchUtils searchUtils = new SearchUtils(preProcessor.createInvertedIndex(documentReader.readDocs()));
        System.out.println("simple or complex searching?");
        String searchType = scanner.next();
        if (searchType.equalsIgnoreCase("simple")) {
            System.out.println("enter the word:");
            System.out.println(searchUtils.simpleSearch(scanner.next()));
        } else if (searchType.equalsIgnoreCase("complex")) {
            System.out.println("enter the expresion:");
            scanner.nextLine();
            System.out.println(searchUtils.complexSearch(scanner.nextLine()));
        } else {
            System.out.println("Wrong searching type!");
        }
    }
}
