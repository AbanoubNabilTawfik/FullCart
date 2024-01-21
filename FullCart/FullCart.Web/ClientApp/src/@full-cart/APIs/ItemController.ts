import { BaseURL } from '../config';

export const ItemController = {
  AddItem: BaseURL + `/api/Item/AddItem`,
  UpdateItem: BaseURL + `/api/Item/UpdateItem`,
  DeleteItem: BaseURL + `/api/Item/DeleteItem`,
  GetAllItems: BaseURL + `/api/Item/GetAllItems`,
};
