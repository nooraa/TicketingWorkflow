import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketRequestComponent } from './Components/ticket-request-component/ticket-request-component';
import { SystemDashboardComponent } from './Components/system-dashboard-component/system-dashboard-component';
import { LoginComponent } from './Components/login-component/login-component';
import { AuthGuardService } from './Services/Auth-Guard-Service';


const routes: Routes = [

  {
    path: '',
    component: TicketRequestComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'dashboard',
    component: SystemDashboardComponent,
    //canActivate: [ AuthGuardService ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
