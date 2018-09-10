import { Component, OnInit } from '@angular/core';
import { WarehouseModel } from '../../models/warehouses/warehouseModel';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormsModule }   from '@angular/forms';
//Register products data service
import { WarehousesService} from '../../services/warehouses/warehouses.service';

@Component({
  selector: 'app-warehouse-detail',
  templateUrl: './warehouse-detail.component.html',
  styleUrls: ['./warehouse-detail.component.css']
})
export class WarehouseDetailComponent implements OnInit {

  public isLoading: boolean;
  public id: string;
  public model: WarehouseModel = new WarehouseModel();

  private warehousesService: WarehousesService;
  private route: ActivatedRoute;
  private router: Router;

  constructor(warehousesService: WarehousesService, route: ActivatedRoute, router: Router) {
    this.warehousesService = warehousesService;

    this.route = route;
    this.router = router;

    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
    });
  }

  ngOnInit() {
    this.fetchData();
  }

  fetchData(){
    this.warehousesService.getItemById(this.id).subscribe(
      (data) => {
        this.model = data;
      }, 
      () => { //This is 2st callback, describes ERROR result
          console.error("err");
      },
      () => { //This is 3st callback, describes that Observable is COMPLETED
          console.log(this.model);      
      });
  }

}
