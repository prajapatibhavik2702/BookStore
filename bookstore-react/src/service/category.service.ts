import request from "./request";
import FilterModel from "../models/FilterModel";
import BaseList from "../models/BaseList";
import { CategoryModel } from "../models/CategoryModel";

class CategoryService {
    //ENDPOINT = 'Category';

    public async getAll(params: FilterModel): Promise<BaseList<CategoryModel[]>> {
        const url = `/list`;
        return request.get<BaseList<CategoryModel[]>>(url, {params} ).then((res) => {
            return res.data;
        });
    }

    public async getById(id: number): Promise<CategoryModel> {
        const url = `category/${id}`;
        return request.get<CategoryModel>(url).then((res) => {
            return res.data;
        });
    }

    public async delete(id: number): Promise<CategoryModel> {
        const url = `/Delete/${id}`;
        return request.delete<CategoryModel>(url).then((res) => {
            return res.data;
        });
    }

    public async save(data: CategoryModel): Promise<CategoryModel> {
        if (data.id) {
            const url = `category/Update`;
            return request.put<CategoryModel>(url, data ).then((res) => {
                return res.data;
            });
        } else {
            const url = `category/Add`;
            return request.post<CategoryModel>(url, data ).then((res) => {
                return res.data;
            });
        }
    }

}
export default new CategoryService();
