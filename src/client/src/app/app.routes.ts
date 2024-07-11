import { Routes } from '@angular/router';
import { NotfoundComponent } from './errorPages/notfound/notfound.component';
import { IndexComponent } from './pages/index/index.component';
import { HomeComponent } from './pages/home/home.component';
import { DashboardComponent } from './Admin/dashboard/dashboard.component';
import { ServicesComponent } from './Admin/services/services.component';
import { OverviewComponent } from './Admin/overview/overview.component';
import { ServicespageComponent } from './pages/servicespage/servicespage.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
    {path: "", redirectTo: "index/home", pathMatch: "full"},
    {path: "admin/dashboard", component: DashboardComponent, children: [
        {path: "services", component: ServicesComponent},
        {path: "overview", component: OverviewComponent},
    ]},
    {path: "index", component: IndexComponent, children: [
        {path: "home", component:HomeComponent},
        {path: "services", component: ServicespageComponent},
        {path: "about", component: AboutComponent},
        {path: "contacts", component: ContactsComponent},
        {path: "login", component: LoginComponent},
    ]},
    {path: "**", redirectTo: "pagenotfound", pathMatch: "full"},
    {path: "pagenotfound", component:NotfoundComponent, title:"PageNotFound"}
];
