import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { LoginService } from './login-Service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

    constructor(public loginService: LoginService, public router: Router) { }

    async canActivate(): Promise<boolean> {
        if (!this.loginService.isAuthenticated) {
            this.router.navigate(['login']);
            return false;
        }
        return true;
    }
}