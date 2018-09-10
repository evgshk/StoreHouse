import { Component, OnInit } from '@angular/core';
//Register products data service
import { ProductsService} from '../../services/products/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public isLoading: boolean;
  public data: any[] = new Array();
  private productsService: ProductsService;

  constructor(productsService: ProductsService) {
    this.productsService = productsService;
  }

  ngOnInit() {
    this.fetchData();
  }

  fetchData(){
    this.productsService.getItems().subscribe(
      (data) => {
        this.data = data;
      }, 
      () => { //This is 2st callback, describes ERROR result
          console.error("err");
      },
      () => { //This is 3st callback, describes that Observable is COMPLETED
          console.log(this.data);      
      });
  }
}
