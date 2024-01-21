import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BrandController } from '../APIs/BrandController';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  constructor(private httpService: HttpService) { }

  
  AddBrand(model: any) {
    return this.httpService.POST( BrandController.AddBrand, model);
  }
  GetAllBrands() {
    return this.httpService.GET(BrandController.GetAllBrands);
  }

  UpdateBrand(model: any) {
    return this.httpService.POST(BrandController.UpdateBrand, model);
  }
}
