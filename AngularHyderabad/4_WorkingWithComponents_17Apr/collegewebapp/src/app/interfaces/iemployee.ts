import { IAddress } from './iaddress';

export interface IEmployee {

  fullName: string;

  pictureUrl: string;

  department: string;

  age: number;

  address: IAddress;
}
