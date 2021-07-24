import java.util.*;

public class Main {
    static void run(String searchWord) {
        GetInput getInput = new GetInput("C:/Users/ASUS/Downloads/SampleEnglishData/EnglishData");
        HashMap<Integer, String> hashMap = getInput.readContent();
        InvertedIndex invertedIndex = new InvertedIndex();

        for (int id : hashMap.keySet()) {
            String docString = hashMap.get(id);
            Tokenizer tokenizer = new Tokenizer(docString);
            HashSet<String> wordsSet = tokenizer.tokenize();
            invertedIndex.addDoc(wordsSet, id);
        }

        HashSet<Integer> foundDocs = invertedIndex.getWordDocs(searchWord);
        TreeSet<Integer> sortedDocs = new TreeSet<Integer>(foundDocs);
        System.out.println(sortedDocs);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String searchWord = scanner.nextLine();
        run(searchWord);
    }
}
