import {inject} from 'aurelia-dependency-injection';
import {Router} from 'aurelia-router';

@inject(Router)
export class Home {
    Router: Router;

    constructor(router: Router) {
        this.Router = router;
    }

    mzrRoute():string {
        let retVal = this.Router.generate("../passport-mzr-validation/passport-mzr-validation");
        return retVal;
    }
}
