import { Component, OnInit } from '@angular/core';
//Register products data service
import { DocumentsService} from '../../services/documents/documents.service';

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.css']
})
export class DocumentsComponent implements OnInit {

  public isLoading: boolean;
  public data: any[] = new Array();
  private documentsService: DocumentsService;

  constructor(documentsService: DocumentsService) {
    this.documentsService = documentsService;
  }

  ngOnInit() {
    this.fetchData();
  }

  fetchData(){
    this.documentsService.getItems().subscribe(
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