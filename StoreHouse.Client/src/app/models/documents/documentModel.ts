import { WarehouseModel } from '../warehouses/warehouseModel'
import { ProductModel } from '../products/productModel'

export class DocumentModel {
    public warehouseFrom: WarehouseModel = new WarehouseModel();
    public warehouseTo: WarehouseModel = new WarehouseModel();
    public product: ProductModel = new ProductModel();
    public value: number;
}