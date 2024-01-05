import { HttpClient } from "@angular/common/http";
import { Environment } from "../../environments/environment";
import { User } from "../model/user";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";

//Class to access the api endpoint for login
@Injectable()
export class RegisterService{
    //Base URL to direct to
    baseUrl = Environment.apiUrl;
    //Default CTOR
    constructor(private http: HttpClient){}

    //Login method
    register(user: User){
        return this.http.post(this.baseUrl + 'UserRegister', user).pipe(
            map((response: any) => {
                user = response; 
            })
        )
    }
}