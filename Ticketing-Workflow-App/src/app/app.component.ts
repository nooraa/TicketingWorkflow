import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Ticketing-Workflow-App';
  isAuthenticated = false;
  constructor(private router: Router){

  }
   logout():void {
    this.router.navigate(['/']);
  }
}
