# Image-Tagger
A super simple image viewer with the ability to tag images, search by tags, and define clipping regions for AI training purposes

![preview image](ImageTagger_v3.png)
![preview image](ImageTagger_v4.png)

Controls:
* Left/Right to scroll images, or click on the edges
* Space to enter/exit gallery slideshow mode (Escape also exits)
* Mouse click to pan, mouse wheel to zoom
* Drag in more than one image to begin a batch. Dragging in more images adds to the batch.

Implemented:
* Tagging
* Searching images by tags
* Saving/Loading the database of image locations, image tags, and image training regions
* Definable regions for AI training (manual text input for now)
* Gallery functionality
* Full-screen slideshow with speed setting
* Interpolation options
* Somewhat efficient handling of large volumes of images (dragging in tens of thousands may take a minute)

Not Implemented:
* Removing images from the current batch
* Removing images from the database (can be done manually with a text editor)
* Negative search terms
* WebP support, GIF playback
* A visual tool to select training regions
