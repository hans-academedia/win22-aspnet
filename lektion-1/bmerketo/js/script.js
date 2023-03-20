try {

    
    const toggleButton = document.querySelector('[data-option="toggle"]')
    const target = toggleButton.getAttribute('data-target')
    toggleButton.addEventListener('click', toggleTarget)

    function toggleTarget() {
        console.log('test')
        
        const element = document.querySelector(target)

        if (!element.classList.contains('hide')) {
            element.classList.add('hide')
        } else {
            element.classList.remove('hide')
        }
    }
} catch {}