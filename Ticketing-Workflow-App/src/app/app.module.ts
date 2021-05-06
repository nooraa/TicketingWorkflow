import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule} from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSliderModule } from '@angular/material/slider';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { TicketRequestComponent } from './Components/ticket-request-component/ticket-request-component';
import { TicketManagmenetService } from './Services/ticket-Managment-Service';
import { LoginService } from './Services/login-Service';
import { AuthGuardService } from './Services/Auth-Guard-Service';
import { LoginComponent } from './Components/login-component/login-component';
import { SystemDashboardComponent } from './Components/system-dashboard-component/system-dashboard-component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import {CdkTableModule} from '@angular/cdk/table';
import { MatSortModule } from "@angular/material/sort";
import { MatTableModule } from "@angular/material/table";
import {MatDialogModule} from '@angular/material/dialog';
import {MatCheckboxModule} from '@angular/material/checkbox';
@NgModule({
  declarations: [
    AppComponent,
    TicketRequestComponent,
    LoginComponent,
    SystemDashboardComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
    FormsModule,
    CdkTableModule,
    MatCheckboxModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatSortModule,
    MatTableModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatSliderModule,
    MatInputModule,
    MatAutocompleteModule,
    HttpClientModule,
    MatDialogModule
  ],
  providers: [
    TicketManagmenetService,
    LoginService,
    AuthGuardService
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
