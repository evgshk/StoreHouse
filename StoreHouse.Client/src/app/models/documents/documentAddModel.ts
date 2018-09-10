import { WarehouseModel } from '../warehouses/warehouseModel'
import { ProductModel } from '../products/productModel'
import { DocumentModel } from './documentModel';

export class DocumentAddModel extends DocumentModel {
    public warehouseFromDdl: WarehouseModel[] = new Array<WarehouseModel>();
    public warehouseToDdl: WarehouseModel[] = new Array<WarehouseModel>();
    public productDdl: ProductModel[] = new Array<ProductModel>();
}