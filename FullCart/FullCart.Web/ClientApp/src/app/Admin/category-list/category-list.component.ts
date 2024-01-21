import { Component, OnInit } from '@angular/core';
import { Category } from 'src/@full-cart/Models/Category/Category';
import { ResponseDto } from 'src/@full-cart/Models/Common/response';
import { AlertService } from 'src/@full-cart/Services/alert.service';
import { CategoryService } from 'src/@full-cart/Services/category.service';
import { BaseURL } from 'src/@full-cart/config';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories: Category[] = [];

  constructor(private categoryService:CategoryService,private alertService: AlertService)
  {

  }
 

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories()
  {
    this.categoryService.GetAllCategories().subscribe(
      (res:ResponseDto)=>{
           if(res.isPassed)
           {
            console.log("res",res)
            this.categories=res.data;
            for(var i=0;i<this.categories.length;i++)
            {
              this.categories[i].image=BaseURL+this.categories[i].image;
            }
            this.alertService.showSuccess(res.message);
           }
      },
      error=>{
        this.alertService.showError(error.message);
      }
    )
  }

  deleteCategory(id:any)
  {

  }
}
