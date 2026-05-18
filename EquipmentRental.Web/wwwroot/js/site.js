// Site-wide JavaScript functions

// Auto-dismiss alerts after 5 seconds
$(document).ready(function () {
    setTimeout(function () {
        $('.alert-dismissible').alert('close');
    }, 5000);
});

// Initialize tooltips
$(function () {
    $('[data-bs-toggle="tooltip"]').tooltip();
});

// Initialize popovers
$(function () {
    $('[data-bs-toggle="popover"]').popover();
});

// Dynamic file input label
$(document).ready(function () {
    $('.custom-file-input').on('change', function () {
        let fileName = $(this).val().split('\\').pop();
        $(this).next('.custom-file-label').html(fileName);
    });
});

// Calculate rental cost based on dates
function calculateRentalCost() {
    const startDateInput = document.getElementById('RentalStartDate');
    const endDateInput = document.getElementById('RentalEndDate');
    const rentalPriceInput = document.getElementById('RentalPrice');
    const totalCostDisplay = document.getElementById('totalCostDisplay');

    if (startDateInput && endDateInput && rentalPriceInput && totalCostDisplay) {
        const startDate = new Date(startDateInput.value);
        const endDate = new Date(endDateInput.value);
        const rentalPrice = parseFloat(rentalPriceInput.value);

        if (!isNaN(startDate.getTime()) && !isNaN(endDate.getTime()) && !isNaN(rentalPrice)) {
            // Calculate the difference in days (add 1 to include both start and end days)
            const timeDiff = endDate.getTime() - startDate.getTime();
            const dayDiff = Math.floor(timeDiff / (1000 * 3600 * 24)) + 1;

            if (dayDiff > 0) {
                const totalCost = dayDiff * rentalPrice;
                totalCostDisplay.textContent = totalCost.toFixed(2);

                // If there's a hidden field for total cost, update it as well
                const totalCostInput = document.getElementById('TotalCost');
                if (totalCostInput) {
                    totalCostInput.value = totalCost.toFixed(2);
                }
            } else {
                totalCostDisplay.textContent = '0.00';
            }
        }
    }
}

// Calculate refund amount based on damage fee
function calculateRefundAmount() {
    const depositAmountInput = document.getElementById('DepositAmount');
    const damageFeeInput = document.getElementById('DamageFee');
    const refundAmountInput = document.getElementById('RefundAmount');
    const refundAmountDisplay = document.getElementById('refundAmountDisplay');

    if (depositAmountInput && damageFeeInput && refundAmountInput && refundAmountDisplay) {
        const depositAmount = parseFloat(depositAmountInput.value) || 0;
        const damageFee = parseFloat(damageFeeInput.value) || 0;

        let refundAmount = depositAmount - damageFee;
        if (refundAmount < 0) refundAmount = 0;

        refundAmountInput.value = refundAmount.toFixed(2);
        refundAmountDisplay.textContent = refundAmount.toFixed(2);
    }
}

// Show/hide damage fee input based on return condition
function toggleDamageFee() {
    const returnConditionSelect = document.getElementById('ReturnCondition');
    const damageFeeGroup = document.getElementById('damageFeeGroup');

    if (returnConditionSelect && damageFeeGroup) {
        if (returnConditionSelect.value === 'Damaged' || returnConditionSelect.value === 'Lost') {
            damageFeeGroup.classList.remove('d-none');
        } else {
            damageFeeGroup.classList.add('d-none');
            const damageFeeInput = document.getElementById('DamageFee');
            if (damageFeeInput) {
                damageFeeInput.value = '0.00';
            }
        }

        // Recalculate refund amount
        calculateRefundAmount();
    }
}

// Star rating functionality
function setRating(rating) {
    document.getElementById('Rating').value = rating;

    // Update star colors
    for (let i = 1; i <= 5; i++) {
        const star = document.getElementById('star' + i);
        if (star) {
            if (i <= rating) {
                star.classList.remove('far');
                star.classList.add('fas');
            } else {
                star.classList.remove('fas');
                star.classList.add('far');
            }
        }
    }
}