export async function getHtml(url) {
    const r = await fetch(url);
    if (!r.ok) throw new Error("Грешка при зареждане");
    return r.text();
}

export async function postForm(url, formData) {
    const r = await fetch(url, {
        method: "POST",
        body: formData
    });
    if (!r.ok) throw new Error("Грешка при запис");
    return r.json();
}