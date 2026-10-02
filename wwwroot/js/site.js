(() => {
  const index = document.getElementById("index");
  document.getElementById("open-index")?.addEventListener("click", () => index?.showModal());
  document.getElementById("close-index")?.addEventListener("click", () => index?.close());
  index?.addEventListener("click", (event) => {
    if (event.target === index) index.close();
  });
  index?.querySelectorAll("a").forEach((link) => link.addEventListener("click", () => index.close()));

  const zoom = document.getElementById("zoom");
  const zoomBody = zoom?.querySelector(".zoom-body");
  const zoomTitle = document.getElementById("zoom-title");
  document.getElementById("close-zoom")?.addEventListener("click", () => zoom?.close());
  zoom?.addEventListener("click", (event) => {
    if (event.target === zoom) zoom.close();
  });
  document.querySelectorAll("[data-zoom]").forEach((button) => {
    button.addEventListener("click", () => {
      const plate = button.closest("article")?.querySelector(".plate")
        || document.querySelector(".detail .plate");
      if (!plate || !zoom || !zoomBody) return;
      zoomBody.replaceChildren(plate.cloneNode(true));
      if (zoomTitle) zoomTitle.textContent = button.dataset.title || "";
      zoom.showModal();
    });
  });

  const progress = document.getElementById("progress");
  const onScroll = () => {
    const max = document.documentElement.scrollHeight - window.innerHeight;
    const ratio = max > 0 ? window.scrollY / max : 0;
    if (progress) progress.style.transform = `scaleX(${ratio})`;
    document.querySelector(".site-header")?.classList.toggle("is-scrolled", window.scrollY > 8);
  };
  window.addEventListener("scroll", onScroll, { passive: true });
  onScroll();

  const reduce = window.matchMedia("(prefers-reduced-motion: reduce)").matches;

  const film = document.getElementById("film");
  const toggle = document.getElementById("film-toggle");
  const video = document.getElementById("hero-video");
  if (reduce && video) video.pause();
  toggle?.addEventListener("click", () => {
    const paused = film?.classList.toggle("is-paused");
    toggle.setAttribute("aria-pressed", paused ? "true" : "false");
    toggle.textContent = paused ? toggle.dataset.play : toggle.dataset.pause;
    if (video) {
      if (paused) video.pause();
      else video.play();
    }
  });

  const panorama = document.getElementById("panorama");
  if (panorama) {
    let active = false;
    let startX = 0;
    let startLeft = 0;
    panorama.addEventListener("pointerdown", (event) => {
      active = true;
      startX = event.clientX;
      startLeft = panorama.scrollLeft;
      panorama.setPointerCapture(event.pointerId);
    });
    panorama.addEventListener("pointermove", (event) => {
      if (!active) return;
      panorama.scrollLeft = startLeft - (event.clientX - startX);
    });
    panorama.addEventListener("pointerup", () => { active = false; });
  }

  const stage = document.querySelector(".stage");
  const cube = document.getElementById("cube");
  if (stage && cube) {
    let dragging = false;
    let rotation = 0;
    let lastX = 0;
    stage.addEventListener("pointerdown", (event) => {
      dragging = true;
      lastX = event.clientX;
      stage.setPointerCapture(event.pointerId);
      cube.style.animation = "none";
    });
    stage.addEventListener("pointermove", (event) => {
      if (!dragging) return;
      rotation += (event.clientX - lastX) * 0.45;
      lastX = event.clientX;
      cube.style.transform = `rotateY(${rotation}deg)`;
    });
    stage.addEventListener("pointerup", () => { dragging = false; });
  }

  document.querySelectorAll("[data-fill]").forEach((button) => {
    button.addEventListener("click", () => {
      const field = document.querySelector("[data-amount-field]");
      if (!(field instanceof HTMLInputElement)) return;
      field.value = button.dataset.fill || "";
      field.focus();
    });
  });

  document.getElementById("print-dossier")?.addEventListener("click", () => window.print());
})();
