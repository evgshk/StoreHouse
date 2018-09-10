import{ StockItemModel } from '../stocks/stockItemModel';

export class WarehouseModel{
    public id: string;
    public code: string;
    public adress: string;
    public name: string;
    public stocks: StockItemModel[];

    constructor(){
        this.id = "";
        this.code = "";
        this.name = "";
        this.adress = "";
        this.stocks = new Array<StockItemModel>();
    }
}