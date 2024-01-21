import { Component, OnInit } from '@angular/core';
import { ResponseDto } from 'src/@full-cart/Models/Common/response';
import { Item } from 'src/@full-cart/Models/Item/item';
import { AlertService } from 'src/@full-cart/Services/alert.service';
import { ItemsService } from 'src/@full-cart/Services/items.service';
import { BaseURL } from 'src/@full-cart/config';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  items: Item[] = [];
  constructor(private itemService:ItemsService,private alertService: AlertService)
  {

  }

  ngOnInit(): void {
   this.loadItems();
  }

  loadItems()
  {
    this.itemService.GetAllItems().subscribe(
      (res:ResponseDto)=>{
           if(res.isPassed)
           {
            console.log("res",res)
            this.items=res.data;
            for(var i=0;i<this.items.length;i++)
            {
              this.items[i].image=BaseURL+this.items[i].image;
            }
            this.alertService.showSuccess(res.message);
           }
      },
      error=>{
        this.alertService.showError(error.message);
      }
    )
  }
  deleteItem(id:any)
  {

  }

}
