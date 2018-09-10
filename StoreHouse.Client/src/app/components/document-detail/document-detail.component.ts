import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormsModule }   from '@angular/forms';
//Register products data service
import { DocumentsService} from '../../services/documents/documents.service';
//Import Document model
import { DocumentModel } from '../../models/documents/documentModel';

@Component({
  selector: 'app-document-detail',
  templateUrl: './document-detail.component.html',
  styleUrls: ['./document-detail.component.css']
})
export class DocumentDetailComponent implements OnInit {

  public isLoading: boolean;
  public id: string;
  public model: DocumentModel = new DocumentModel();

  private documentsService: DocumentsService;
  private route: ActivatedRoute;
  private router: Router;

  constructor(documentsService: DocumentsService, route: ActivatedRoute, router: Router) {
    this.documentsService = documentsService;

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
    this.documentsService.getItemById(this.id).subscribe(
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
