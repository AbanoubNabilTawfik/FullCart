export class ResponseDto {
    isPassed?: boolean;
    message: string="";
    data: any;
    totalPageCount?:number
    totalCount?:number
}
export class QueryParamsDto {
    key?: string;
    value: any;
}