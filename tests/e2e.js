import { Selector } from 'testcafe';

fixture("Tests").page("http://http://5.189.170.247:5001/home");
test("Create Task Test", async (t) => {
    await t.click("#addTask");
    await t.wait(1000);
    await t.typeText(".native-input.sc-ion-input-md", "Test Task Name");
    await t.wait(1000);
    await t.click("#createTask");
    await t.wait(3000);
    await t.expect(Selector("body > app-root > ion-app > ion-router-outlet > app-home > ion-content > ion-grid > ion-row > ion-col > ion-card > ion-card-header > ion-card-title").innerText).eql("Test Task Name");
});

test("Delete Task Test", async (t) => {
    await t.click("#deleteTask");
    await t.wait(1000);
    await t.expect(Selector("body > app-root > ion-app > ion-router-outlet > app-home > ion-content > ion-grid > ion-row > ion-col > ion-card > ion-card-header > ion-card-title").exists).notOk();
})