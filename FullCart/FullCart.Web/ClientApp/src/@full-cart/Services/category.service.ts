import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { CategoryController } from '../APIs/CategoryController';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpService: HttpService) { }

  
  AddCategory(model: any) {
    return this.httpService.POST( CategoryController.AddCategory, model);
  }
  GetAllCategories() {
    return this.httpService.GET(CategoryController.GetAllCategories);
  }

  UpdateCategory(model: any) {
    return this.httpService.POST(CategoryController.UpdateCategory, model);
  }
}
