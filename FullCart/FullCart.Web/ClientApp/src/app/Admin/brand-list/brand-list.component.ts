import { Component, OnInit } from '@angular/core';
import { ResponseDto } from 'src/@full-cart/Models/Common/response';
import { Brand } from 'src/@full-cart/Models/brand/brand';
import { AlertService } from 'src/@full-cart/Services/alert.service';
import { BrandService } from 'src/@full-cart/Services/brand.service';
import { BaseURL } from 'src/@full-cart/config';

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent implements OnInit {
  brands: Brand[] = [];

  constructor(private brandService:BrandService,private alertService: AlertService)
  {

  }
 
  ngOnInit(): void {
    this.getAllBrands();
  }

  getAllBrands()
  {
    this.brandService.GetAllBrands().subscribe(
      (res:ResponseDto)=>{
           if(res.isPassed)
           {
            console.log("res",res)
            this.brands=res.data;
            for(var i=0;i<this.brands.length;i++)
            {
              this.brands[i].image=BaseURL+this.brands[i].image;
            }
            this.alertService.showSuccess(res.message);
           }
      },
      error=>{
        this.alertService.showError(error.message);
      }
    )
  }
 
  deleteBrand(id:any)
  {

  }
}
