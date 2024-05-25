

public class BusinessContext {

    public AssetsContext assetsContext;

    public CardRepository cardRepository;
    public int cardCount;
    public BusinessContext() {
        cardRepository = new CardRepository();
        assetsContext = new AssetsContext();
        cardCount = 0;
    }

    // public void Inject(AssetsContext assetsContext) {
    //     this.assetsContext = assetsContext;
    // }

}