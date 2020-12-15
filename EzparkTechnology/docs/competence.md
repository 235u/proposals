# Competence

Inspired by the [Programmer Competency Matrix](https://sijinjoseph.com/programmer-competency-matrix/) by Sijin Joseph, an oldie but goldie

## Experience

- Has 15 years of professional experience
- Has used more than one framework in a professional capacity and is well-versed with the idioms of the frameworks
- Has written libraries that sit on top of the APIs to simplify frequently used tasks and to fill in gaps in the API

### Languages

Has written code in:

- C (compiled, curly-brace, imperative, procedural, system programming language with manual, deterministic memory management)
- C++ (compiled, curly-brace, imperative, metaprogramming, multiparadigm, object-oriented [class-based, single dispatch], procedural, system programming language with manual, deterministic memory management)
- **C#** (compiled [into IL], curly-brace, functional [impure], imperative, interactive mode, iterative, garbage collected, multiparadigm, object-oriented [class-based, single dispatch], procedural, reflective language)
- **CSS** (style sheet language)
- **HTML** (markup language)
- Java (compiled [into IL], concurrent, curly-brace, functional (impure), imperative, interactive mode, garbage collected, multiparadigm, object-oriented [class-based, single-dispatch], procedural, reflective language)
- **JavaScript** / ECMAScript (curly-brace, embeddable [in source code, client- and server-side], extension, functional [impure], interactive mode, interpreted, garbage collected, multiparadigm, object-oriented [prototype-based], procedural, reflective, scripting language)
- LaTeX (markup language)
- **Mardown** (markup language)
- PHP (curly-brace, embeddable [in source code, server-side], imperative, interpreted, imperative, iterative, garbage collected [combined with automated reference counting], multiparadigm, object-oriented [class-based, single dispatch], reflective, scripting language)
- **PowerShell** (command line interface, curly-brace, extension, garbage collected, imperative, interactive mode, interpreted, multiparadigm, procedural, reflective, scripting language)
- **SQL** (data-oriented, declarative, fourth-generation, little language [serving a specialized problem domain])
- **SVG** (markup language)
- **TypeScript** (class-based superset of JavaScript)
- UML (modeling language)
- VBA (compiled [into IL], extension, procedural, scripting language with automated reference counting)
- XAML (user interface markup language)
- **XML** (meta markup language)

### Platforms

Has written code on and for:

- GNU/Linux (Debian / Ubuntu)
- **Microsoft Azure**
- Microsoft DOS (6.22)
- **Microsoft Windows** (7 / 8 / 10 / CE / Server / Vista / XP)

## Capacity

Is able to:

- Understand the complete picture
- Recognize and code dynamic programming solutions
- Communicate thoughts / design / ideas / specs in an unambiguous manner
- Effectively use the IDE using menus and keyboard shortcuts for the most used operations

### Systems Decomposition

- Break up problem space and design solutions, that span multiple technologies / platforms
- Visualize and design systems with multiple product lines and integrations with external systems
- Design good and normalized database schemas keeping in mind the queries that will have to be run
- Implement operations support systems like monitoring, reporting, etc.

### Problem Decomposition

- Break up problems into multiple functions
- Come up with reusable functions / objects that solve the overall problem
- Write generic / object-oriented code, that encapsulate aspects of the problem that are subject to change, using appropriate data structures and algorithms

## Modus operandi

Follows Kent Beck's four rules of Simple Design (in Martin Fowler's [interpretation](https://martinfowler.com/bliki/BeckDesignRules.html)), in order of importance:

1.	Passes the tests (including non-automated / manually executed tests)
2.	Reveals intention (purpose is easy to understand)
3.	Contains no duplication (everything should be said "once and only once")
4.	Minimizes the number of elements (anything that doesn't serve the three prior rules should be removed)

### Requirements

- Comes up with questions regarding missed cases / areas that need to be speced
- Suggests better alternatives / flows to given requirements based on experience, feedback, tests, and measurements
- Adjusts communication as per the context (peers can understand what is being said)

### Configuration management

- Can set up automated functional, load / performance, and UI tests; continuous delivery and deployment
- Is proficient in using centralized (CVS / SVN / TFS) and distributed version control systems (Git / Mercurial)
- Knows how to branch and merge, setup repository properties, etc.

### Defensive coding

- Asserts critical assumptions in code
- Checks externally set arguments
- Makes sure to check return values and check for exceptions around code that can fail
- Comes up with good unit test cases for the code that is being written
- Writes unit tests that simulate faults

### Error handling	

- Comes up with guidelines on exception handling for the entire system
- Maintains consistent exception handling strategy in all layers of code
- Codes to detect possible exceptions before
- Ensures that errors / exceptions leave the program in a well-defined state (resources, connections, and memory is all cleaned up properly)

## Delivery

### Source tree organization

Relates to the entire set of artifacts that define the system:

- No circular dependencies; binaries, libs, docs, builds, third-party code are all organized into appropriate folders.
- Physical layout of the source tree matches logical hierarchy and organization; directory naming and organization provide insights into the design of the whole system.

### Code organization across files

- Related source files are grouped into folders.
- Each physical file has a unique purpose (for e.g. one class definition, one feature implementation, etc.).
- Code organization at the physical level closely matches the design, and looking at file names and folder distribution provides insights into design.

### Code organization within a file

- Methods are grouped logically and / or by accessibility.
- Code is grouped into regions and well commented with references to other source files.
- Consistent white space usage; files look beautiful.

### Code readability

- Good names for files, folders, variables, classes, methods, etc.
- Comments explaining unusual code, bug fixes, and code assumptions
- No long functions, no deep nesting of conditionals; code flows naturally.

## Knowledge

- Has heard of upcoming technologies in the field
- Knows about alternatives to popular and standard tools

### Data structures 

- Understands basic database concepts, normalization, indices, transactions
- Can do basic database administration, performance / index / query optimization, write advanced select queries
- Understands how databases can be mirrored, replicated, etc.
- Knows basic sorting, searching, and data structure traversal and retrieval algorithms
- Is proficient in the use of the ORM tools
- Considers space and time tradeoffs of arrays, linked lists, dictionaries, priority queues, etc.
- Knows how hashtables can be implemented and how to handle collisions

### Systems programming

- Understands the entire programming stack (compilers, linkers, and interpreters; just-in-time compilation; static and dynamic linking; binary and assembly code; garbage collection, heap, stack, memory addressing; static / dynamic, weak / strong typing, type inference, lazy evaluation)
- Vaguely remembers what assembly code is and how things work at the hardware level (CPU / memory / cache / interrupts / microcode)
- Knows about virtual memory and paging; kernel / user mode, multi-threading, and synchronization primitives
- Understands how networks work, understanding of network protocols and socket level programming
