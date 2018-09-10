import { StoreHouse.ClientPage } from './app.po';

describe('store-house.client App', () => {
  let page: StoreHouse.ClientPage;

  beforeEach(() => {
    page = new StoreHouse.ClientPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
