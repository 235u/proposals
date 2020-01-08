# Ezpark Technology

*The Airbnb Of Parking*, according to [Google Play](https://play.google.com/store/apps/details?id=com.ezparkapp.ezpark) and [Apple App](https://apps.apple.com/us/app/ezpark-shared-parking/id1449009586?ls=1) store apps; see [job details](docs/_static/job-details.pdf) (ongoing project, hourly), as posted on October 28, 2019.

## Quotation

**Accomplished work**, in hours, **by**   
**hourly rate** between **$32.00** and **$64.00**, up for negotiation, depending on your budget / total amount of hours you are willing to pay for to achieve your goals, **results in**   
**total price**.

E.g. minimal hours amount of 256, as an assumption, results in a minimal price of 256 by hourly rate.

###	Timeline

Project start date / date of hire / date of proposal submission / **08/01/2020** – **open end** (as *ongoing project*).

E.g. 32 hours per week up to 256 hours results in a project start date plus 8 weeks timeline.

## Work Structure

**20%** of work, to reach the functional requirements / desired quantity, implementing the happy case, following the happy path, working under ideal / narrow set of conditions, with manual help from the developer; **80%** of rework, to reach the non-functional requirements / desired quality, in an iterative manner, visualized as a spiral; 

**20%** of writing in natural language / English and multiple artificial / technical languages; **80%** of rewriting, to reach higher quality;

**40%** of problem definition; **60%** of problem resolution, whereby the final solution represents its finely detailed problem definition (formulated in natural and artificial languages), being whether right or wrong / true or false, but good or bad / better or worse in reference to the initial state at project start, and having no formal stopping rule / never being perfectly complete (though having natural constraints in form of finite resources for its resolution / time / skill / budget / motivation / state of the market etc.);

**80%** of thinking, analysis / decomposition, synthesis / composition, (logical) induction, deduction / inference; **20%** of acting / adaptive, well thought out, reacting, as analogies.

###	Breakdown

Representing rough approximations, being flexible / adaptive.

#### Core Processes

Primary, resultative task sequences, adding value to / forming the substance of / targeting the final product / service:

- **10%** planning / requirements analysis and documentation / learning domain specifics / estimation; 
- **10%** system and process analysis, structural and object-oriented / process modelling;
- **20%** architecture / design / evaluation of third-party components and services / prototyping;
- **20%** construction / programming;
- **30%** validation / verification / low-level- and high-level-testing / white-box- and black-box-testing / unit-, integration-, system-, load- and acceptance-testing / debugging.

#### Supportive Processes

Organizational, cooperative tasks, running in parallel, targeting all parties involved, including suppliers of third-party products and services, supporting the core processes by:

- **10%** configuration management / infrastructure configuration / versioning and release-management;
- **20%** project / requirements management / spoken and written communication / mitigation and negotiation / documentation;
- **70%** quality assurance / static and dynamic analysis / build- and run-time measurements.

## Competence

See rather technical [description](docs/competence.md).

## Platform

### Features

Follow the links in [Web Applications](#web-application) for details about the (nowadays very large) feature sets of each and every proposed cloud platform / service.

###	Benefits

The benefits of cloud computing in general are:

- reduced investment in upfront costs (hardware, software, space, server management); try before you buy (and buy what you really need then);
- flexible pricing (pay based on usage, not for idle capacity);
- centralized configuration / metering / billing / management of multiple services (from the biggest providers; not to confuse with geographical distribution of their data centers);
- flexible capacity; scale up or down based on actual needs (unlimited by the infrastructure, in theory; depending on web application's own implementation, in practice);
- extreme reliability and world-class security (depending on final customer's implementation and configuration, again).

###	Lifecycle

The lifecycles of the proposed platforms in general are: date of announcement / launch date / date of commercial availability – today, staying well and healthy, being a bigger player on or even controlling the market / having significant market share, not going to die in the near future.

For timelines of major milestones of the biggest providers (continuously updating their already mature services) see:

- [Amazon Web Services](https://en.wikipedia.org/wiki/Timeline_of_Amazon_Web_Services) (commercially available since 2006);
- [Google Cloud Platform](https://en.wikipedia.org/wiki/Google_Cloud_Platform#Timeline) (commercially available since 2010);
- [Microsoft Azure](https://en.wikipedia.org/wiki/Microsoft_Azure#Timeline) (commercially available since 2010).

## High-Level Design

Single, multi-purpose, cloud-based, progressive web application with driver / parking, owner / offering, administrator / management areas, n-factor authentication and role-based authorization.

For details, see [Frameworks, Languages and Libraries](#frameworks-languages-and-libraries), follow the corresponding links for more details / the sub-components.

## Proposals

### Programming Methodology

- Structured, imperative, object-oriented (class-based and prototype-based), functional, procedural, generic, reflective, asynchronous / concurrent / parallel, aspect-, event-, task- and test-driven programming,
- with client- and server-side code execution.

###	Architectural Styles and Patterns

- Monolithic (deployed as a single unit, not as a collection of interacting services and applications), component-based, database-centric, distributed system;
- with layered / multilayered / multitier / n-tier / three-tier / client-server architecture;
- utilizing model-view-controller, publish-subscribe and cloud computing patterns.

See [Architecting Modern Web Applications with ASP.NET Core and Azure](https://aka.ms/webappebook) for more details.

###	Frameworks, Languages and Libraries

Libraries being written in specific languages; frameworks being larger than libraries / compositions of multiple libraries (and other components, e.g. runtimes), written in specific / multiple languages, targeting same / other languages, often being extensions / dialects of another languages.

###	Server-Side Development

For back-end and front-end development across all layers:

<table style="text-align: center">
    <tr>
        <td rowspan="2" style="width: 33%">Web API</td>
        <td colspan="3">Identity</td>
    </tr>
    <tr>
        <td style="width: 16%">Razor Pages</td>
        <td style="width: 16%">MVC</td>
        <td rowspan="2" style="width: 33%">
            Entity Framework Core /
            Dapper
        </td>
    </tr>
    <tr>
        <td colspan="3">ASP.NET Core</td>
    </tr>
    <tr>
        <td colspan="4">.NET Core / C#</td>
    </tr>
</table>




	







and / or 

Telerik UI for ASP.NET Core (based on Kendo UI Professional)
Braintree Server SDK /
SendGrid / Twilio

ASP.NET Core

.NET Core / C#

Integrating components / packages via [NuGet](https://www.nuget.org/).
