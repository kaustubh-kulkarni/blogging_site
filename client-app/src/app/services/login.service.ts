import { HttpClient } from "@angular/common/http";
import { Environment } from "../../environments/environment";
import { User } from "../model/user";
import { map } from "rxjs/operators";
import { Injectable } from "@angular/core";

//Class to access the api endpoint for login
@Injectable()
export class LoginService{
    //Base URL to direct to
    baseUrl = Environment.apiUrl;
    //Default CTOR
    constructor(private http: HttpClient){}

    //Login method
    login(user: User){
        return this.http.post(this.baseUrl + 'UserLogin', user).pipe(
            map((response: any) => {
                const user = response;
                console.info(user.firstname);
            })
        )
    }
}