import { Auditable } from "../Auditable";

export class UserDetailsDto extends Auditable {
    id?: number;
    firstName?: string; 
    lastName?:string;
    email?:string;
    phoneNumber?:string;
    callingCode: any = null; 
    phoneNumberConfirmed: boolean = false;
    changePassword?: boolean;
    emailConfirmed: boolean = false;
    role?:string;
    address?: string;
    personalImagePath?: string; 
}