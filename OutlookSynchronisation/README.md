# Cirrus Shield Outlook Add-in

See [job details](JobDetails.pdf) (complex project, fixed-price), as posted on November 29, 2019, including the screen-by-screen [specification](Specification.pdf), posted as an attachment.

## Questions

Asked to answer when submitting a proposal.

### 1. What challenging part of this job are you most experienced in?

Resolution of [wicked problems](https://en.wikipedia.org/wiki/Wicked_problem) armed with:

- 10+ years of professional software engineering experience based on Microsoft technologies, products, and services in general;
- 25+ years of personal experience as power user in the Microsoft eco-system ... starting with MS DOS and Windows 3.11 / NT 4.0, using MS Office / Outlook by myself.

Feel free to take a look at the [source code](https://github.com/235u/website) (C#, HTML, CSS, and JavaScript) of my personal [website](https://github.com/235u/website).

### 2. Do you have suggestions to make this project run successfully?

The job is posted under `Desktop Software Development`, usually being platform-dependent (e.g. targeting specific Office Desktop Clients), the specification refers i.a. to [Outlook add-ins](https://docs.microsoft.com/en-us/outlook/add-ins/) (more exactly speaking: [the quick start tutorial for Visual Studio](https://docs.microsoft.com/en-us/outlook/add-ins/quick-start?tabs=visualstudio)), being web applications in general:

> Outlook add-ins are different from COM or VSTO add-ins, which are older integrations specific to Outlook running on Windows. Unlike COM add-ins, Outlook add-ins don't have any code physically installed on the user's device or Outlook client. For an Outlook add-in, Outlook reads the manifest and hooks up the specified controls in the UI, and then loads the JavaScript and HTML. The web components all run in the context of a browser in a sandbox.

Which makes the 

> add-in is downloaded and installed

step (see [specification](Specification.pdf), the setup slide) questionable, like

> **Success** and **Error files** will be stored locally in a subfolder of the installation (called **Sync Reports**).

> The application should generate **debug logs** stored in a **log** subfolder of the installation folder.

> On **Save**, an XML file with all the configuration of contacts and events will be
saved locally on the user’s PC in a subfolder of the installation folder.

on the configuration slides. 

In further consequence I would reconsider following features:

> **Automatic Syncs** are done in the background without any interference from the user.

To reduce the complexity / probability of users being interferenced by the automatic synchronisation and get rid of the questions like: Where should the automatic synchronisation run? On the server (host of the web application)? On user's device? In whose background? In the Outlook process? (Being the foreground, usually not running 24/7.)

I would try to replace this with automatic synchronisation on add-ins startup and immediate updates on [changes in user's data](https://docs.microsoft.com/en-us/graph/webhooks#supported-resources) (contacts, calendar events) using webhooks, being always up-to-date in the `Outlook to Cirrus Shield` direction.

> The application should generate **debug logs** stored in a **log** subfolder of the installation folder.

I would prefer Visual Studio's Debugger over text files on end-user's devices; I would not expect the end-users to be alpha and beta testers, trying to deliver bug-free experience, taking the responsibility for the debugging (literally speaking) process, [failing fast](https://en.wikipedia.org/wiki/Fail-fast) during development, supported by test automation, for the crtitical sections / execution paths / (message based) inter process communication part at least.

> On **Save**, an XML file with all the configuration of contacts and events will be
saved locally on the user’s PC in a subfolder of the installation folder.

I would use [Office.RoamingSettings](https://docs.microsoft.com/en-us/office/dev/add-ins/develop/persisting-add-in-state-and-settings) JavaScript interface (or a custom solution, persisting data on the server), due following office [add-in state and settings persistence](https://docs.microsoft.com/en-us/office/dev/add-ins/develop/persisting-add-in-state-and-settings) specifics:

> Office Add-ins are essentially web applications running in the stateless environment of a browser control. As a result, your add-in may need to persist data to maintain the continuity of certain operations or features across sessions of using your add-in.

On hire I would like to use

- Microsoft Azure for hosting the web application part of the add-in,
- Azure DevOps Services with repos (preferably Git), pipelines, and artifacts set up, for version control, configuration management, continous integration and delivery,
- Azure Boards for additional project / issue management, if required,
- Outlook for formal, Skype / Microsoft Teams for non-formal communication,
- Visual Studio 2019 (Enterprise Edition) as integrated development environment,
- [Office UI Fabric](https://docs.microsoft.com/en-us/office/dev/add-ins/design/office-ui-fabric) as front-end framework,

writing in 

- self-explaining C# (7.3 at least), utilizing XML comments, targeting .NET Core (3.0 / current version) for the back-end, 
- HTML5, CSS3, ECMAScript 2015 (ES6, at least) on the client-side / for the front-end, trying to reduce the functionality for the server-side execition, to reduce its load (and your bill) / for [responsive user experience](https://docs.microsoft.com/en-us/office/dev/add-ins/concepts/add-in-development-best-practices?product=outlook#optimize-and-monitor-add-in-performance);
- Markdown (GitHub Flavored),

releasing often and early.

### 3. What past project or job have you had that is most like this one and why?

I've maintained / extended multiple add-ins for: 

- newsletter composition in Microsoft Outlook, as VSTO add-in, written in C#, 2-3 years ago, 
- machinery engineering (component classification / standardisation / management), in Microsoft Word, and Excel (as VSTO add-ins), Autodesk AutoCAD and Inventor, with similar infrastructure (targeting .NET), about 5 years ago.

### 4. What questions do you have about the project?

Your [Developer Guide](https://help.cirrus-shield.com/docs/developer-guide/) states:

> Cirrus Shield allows developers express their creativity and deliver innovative applications to customers faster. Get the required information in order to develop additional features or integrate third-party apps in the CRM using Rest APIs.

How many developers / third-party applications are already using your [Rest API](https://help.cirrus-shield.com/docs/developer-guide/rest-api/)? Is it available in the [OpenAPI Specification](https://swagger.io/resources/open-api/) form? Is it delta query capable like [Microsoft Graph](https://docs.microsoft.com/en-us/graph/delta-query-overview) (referenced in the specification; thinking about `Cirrus Shield to Outlook` and `Both ways` synchronisation directions)?

What does this

> I am willing to pay higher rates for the most experienced freelancers

mean to you in numbers?

Furthermore I would be interested in:

- the upper budget boundary, recompensation model for additional features (on scope and feature creep, if any, according expediture); 
- the overall time-schedule / release plan / milestones;
- products and services you are more comfortable with (GitHub, Slack, Discord, Trello, Jira etc.);
- technology stack of your CRM;
- non-functional requirements (performance constraints, number of users, contacts / calendar events to sync on average); 
- quality assurance assistance, sample data / account for testing purposes;
- add-in distribution ([AppSource / Office Store](https://docs.microsoft.com/en-us/office/dev/store/submit-to-the-office-store), deployed by Office 365 tenancy administrators across their organizations)
- further maintenance in production.

## Issues

### JavaScript Library

The link to the [JavaScript Library](https://help.cirrus-shield.com/docs/developer-guide/javascript-library/) (seems to be better documented than the [REST API](https://help.cirrus-shield.com/docs/developer-guide/rest-api/))

```html
<script src=" https://cirrus-shield.net/ /Content/CirrusShield/CirrusShieldJS.js"></script>
````

is broken; the https://cirrus-shield.net SSL certificate is invalid.

