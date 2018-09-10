import { Component, OnInit } from '@angular/core';
//Register products data service
import { DocumentsService} from '../../services/documents/documents.service';
//Import Document model
import { DocumentAddModel } from '../../models/documents/documentAddModel';

@Component({
  selector: 'app-document-add',
  templateUrl: './document-add.component.html',
  styleUrls: ['./document-add.component.css']
})
export class DocumentAddComponent implements OnInit {

  public isLoading: boolean;
  public model: DocumentAddModel = new DocumentAddModel();

  private documentsService: DocumentsService;

  constructor(documentsService: DocumentsService) {
    this.documentsService = documentsService;
  }

  ngOnInit() {
    this.fetchData();
  }

  fetchData(){
    this.documentsService.getItemAddModel().subscribe(
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

  saveChanges(){
    this.documentsService.addItem(this.model).subscribe(
      () => {},
      () => {},
      () => {}
    )
  }

  onChangeWarehouseFrom(){
    console.log(this.model.warehouseFrom.id);
  }
}
