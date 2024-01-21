import { BaseURL } from '../config';

export const CategoryController = {
  AddCategory: BaseURL + `/api/Category/AddCategory`,
  UpdateCategory: BaseURL + `/api/Category/UpdateCategory`,
  GetAllCategories: BaseURL + `/api/Category/GetAllCategories`,
};
