import { Component } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddProductModalComponent } from './add-product-modal/add-product-modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProductManagement';

  constructor(private dialog : MatDialog){

  }

  addProduct(){
    this.dialog.open(AddProductModalComponent, {
      height: '400px',
      width: '600px',
    });
  }
}
