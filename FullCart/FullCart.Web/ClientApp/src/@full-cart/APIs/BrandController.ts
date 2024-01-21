import { BaseURL } from '../config';

export const BrandController = {
  AddBrand: BaseURL + `/api/Brand/AddBrand`,
  UpdateBrand: BaseURL + `/api/Brand/UpdateBrand`,
  GetAllBrands: BaseURL + `/api/Brand/GetAllBrands`,
};
