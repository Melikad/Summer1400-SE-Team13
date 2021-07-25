import java.util.*;

public class Tokenizer {
    private String doc;

    public Tokenizer(String doc) {
        this.doc = doc;
    }

    /**
     * splits the doc into lowercase clean words (alphabet characters only)
     * 
     * @return set of words
     */
    public HashSet<String> tokenize() {
        doc = doc.toLowerCase();
        HashSet<String> wordsSet = new HashSet<>();
        String[] words = doc.split("\\W+");
        for (int j = 0; j < words.length; j++) {
            wordsSet.add(words[j]);
        }
        return wordsSet;
    }
}