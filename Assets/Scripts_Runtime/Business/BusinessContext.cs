

public class BusinessContext {

    public AssetsContext assetsContext;

    public TemplateContext templateContext;

    public CardRepository cardRepository;
    public int cardCount;
    public BusinessContext() {
        cardRepository = new CardRepository();
        cardCount = 0;
    }

    public void Inject(TemplateContext templateContext, AssetsContext assetsContext) {
        this.templateContext = templateContext;
        this.assetsContext = assetsContext;
    }

}