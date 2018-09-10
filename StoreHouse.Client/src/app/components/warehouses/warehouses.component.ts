import { Component, OnInit } from '@angular/core';

//Register products data service
import { WarehousesService} from '../../services/warehouses/warehouses.service';

@Component({
  selector: 'app-warehouses',
  templateUrl: './warehouses.component.html',
  styleUrls: ['./warehouses.component.css']
})
export class WarehousesComponent implements OnInit {

  public isLoading: boolean;
  public data: any[] = new Array();
  private warehousesService: WarehousesService;

  constructor(warehousesService: WarehousesService) {
    this.warehousesService = warehousesService;
  }

  ngOnInit() {
    this.fetchData();
  }

  fetchData(){
    this.warehousesService.getItems().subscribe(
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