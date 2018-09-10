import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes} from "@angular/router";
import { HttpModule } from "@angular/http";

//Declare our components
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { ProductsComponent } from './components/products/products.component';
import { NavbarComponent } from './components/.shared/navbar/navbar.component';
import { FooterComponent } from './components/.shared/footer/footer.component';
import { WarehousesComponent } from './components/warehouses/warehouses.component';
import { DocumentsComponent } from './components/documents/documents.component';
import { StocksComponent } from './components/stocks/stocks.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { DocumentDetailComponent } from './components/document-detail/document-detail.component';
import { StockDetailComponent } from './components/stock-detail/stock-detail.component';
import { WarehouseDetailComponent } from './components/warehouse-detail/warehouse-detail.component';
import { DocumentAddComponent } from './components/document-add/document-add.component';

//Declare our data services
import { ProductsService } from './services/products/products.service';
import { DocumentsService } from './services/documents/documents.service';
import { WarehousesService } from './services/warehouses/warehouses.service';
import { StocksService } from './services/stocks/stocks.service';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'product/:id', component: ProductDetailComponent },
  { path: 'warehouses', component: WarehousesComponent },
  { path: 'warehouse/:id', component: WarehouseDetailComponent },
  { path: 'documents', component: DocumentsComponent },
  { path: 'document/:id', component: DocumentDetailComponent },
  { path: 'document-add', component: DocumentAddComponent },
  { path: 'stocks', component: StocksComponent },
  { path: 'stock/:id', component: StockDetailComponent },
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductsComponent,
    NavbarComponent,
    FooterComponent,
    WarehousesComponent,
    DocumentsComponent,
    StocksComponent,
    ProductDetailComponent,
    DocumentDetailComponent,
    StockDetailComponent,
    WarehouseDetailComponent,
    DocumentAddComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    HttpModule,
  ],
  providers: [
    ProductsService,
    DocumentsService,
    WarehousesService,
    StocksService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
