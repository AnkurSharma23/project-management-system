import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from '../api.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-product-modal',
  templateUrl: './add-product-modal.component.html',
  styleUrls: ['./add-product-modal.component.css']
})
export class AddProductModalComponent {
  productsForm !: FormGroup;

  constructor(private formBuilder: FormBuilder, private api: ApiService, private dialogRef: MatDialogRef<AddProductModalComponent>) { }

  ngOnInit(): void {
    this.productsForm = this.formBuilder.group({
      productName: ['', Validators.required],
      category: ['', Validators.required],
      price: ['', Validators.required]
    });
  }

  addProduct() {
    if (this.productsForm.valid) {
      this.api.postProduct(this.productsForm.value)
        .subscribe({
          next: (res : any) => {
            console.log("products added!");
            this.productsForm.reset();
            this.dialogRef.close("save");
          },
          error: (err: any) => {
            console.log("error in adding the product!");
          }
        });
    }
  }
}