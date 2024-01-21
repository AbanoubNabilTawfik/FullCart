import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { ItemController } from '../APIs/ItemController';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  constructor(private httpService: HttpService) { }

  
  AddItem(model: any) {
    return this.httpService.POST(ItemController.AddItem, model);
  }
  GetAllItems() {
    return this.httpService.GET(ItemController.GetAllItems);
  }
  DeleteItem(model: any) {
    return this.httpService.DELETE(ItemController.DeleteItem, model);
  }
  UpdateItem(model: any) {
    return this.httpService.POST(ItemController.UpdateItem, model);
  }
}
