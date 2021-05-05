import { Component } from '@angular/core';
import { StartPageComponent } from './Components/start-page-component/start-page-component';
@Component({
  selector: 'app-root',
  entryComponents: [StartPageComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Ticketing-Workflow-App';
}
