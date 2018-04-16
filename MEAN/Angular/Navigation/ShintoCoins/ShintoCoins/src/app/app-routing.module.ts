import { HomeComponent } from './home/home.component';
import { BuyComponent } from './buy/buy.component';
import { SellComponent } from './sell/sell.component';
import { MineComponent } from './mine/mine.component';
import { BrowseComponent } from './browse/browse.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
const routes: Routes = [
    {path: 'home',component: HomeComponent},
    {path: 'buy',component: BuyComponent},
    {path: 'sell',component: SellComponent},
    {path: 'mine',component: MineComponent},
    {path: 'browse',component: BrowseComponent},
    { path: '', pathMatch: 'full', redirectTo: '/home' },
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {
}