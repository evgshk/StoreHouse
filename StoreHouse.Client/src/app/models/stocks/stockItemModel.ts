import { ProductModel } from '../products/productModel'

export class StockItemModel{
    public product: ProductModel;
    public value: number;

    constructor(){
        this.product = new ProductModel();
        this.value = 0;
    }
}